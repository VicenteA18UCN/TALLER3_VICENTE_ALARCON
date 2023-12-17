import { Formik } from "formik";
import { View, StyleSheet, Image } from "react-native";
import { ActivityIndicator, Button, Text, TextInput } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import { useRouter } from "expo-router";
import agent from "../../api/agent";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { login } from "../../store/userSlice";
import { selectEmail } from "../../store/userSlice";
import AsyncStorage from "@react-native-async-storage/async-storage";
import Toast from "react-native-root-toast";

interface props {
  email: string;
  password: string;
}

const LoginScreen = () => {
  const [hidePassword, setHidePassword] = React.useState(true);
  const router = useRouter();
  const dispatch = useDispatch();

  const email = useSelector(selectEmail);

  const handleSubmit = (data: props, resetForm: any) => {
    if (data.email === "" || data.password === "") {
      Toast.show("¡Complete todos los campos!", {
        duration: Toast.durations.LONG,
        position: Toast.positions.BOTTOM,
        shadow: true,
        animation: true,
        hideOnPress: true,
        delay: 0,
        containerStyle: {
          backgroundColor: "#FF0000",
        },
      });
      return;
    }
    console.log(data);

    agent.Auth.login(data.email, data.password)
      .then((response) => {
        console.log(response);
        AsyncStorage.setItem("token", response.token);
        dispatch(login(response.token));
        router.push("/(drawer)/repos/repository");
        resetForm();
      })
      .catch((error) => {
        let errorDefault: string = "Ha ocurrido un error. Intente nuevamente.";
        console.log(error.data);
        switch (error.status) {
          case 400:
            if (error.data.errors?.Email) {
              if (error.data.errors.Email.includes("The email is not valid")) {
                errorDefault = "El correo electrónico no es válido.";
              }
            } else if (error.data === "Invalid Credentials") {
              errorDefault = "Credenciales inválidas.";
            }
            break;
          case 500:
            errorDefault = "Ha ocurrido un error. Intente nuevamente.";
            break;
          default:
            break;
        }

        Toast.show(errorDefault, {
          duration: Toast.durations.LONG,
          position: Toast.positions.BOTTOM,
          shadow: true,
          animation: true,
          hideOnPress: true,
          delay: 0,
          containerStyle: {
            backgroundColor: "#FF0000",
          },
        });
      });
  };

  const handleHidePassword = () => {
    setHidePassword(!hidePassword);
  };

  return (
    <SafeAreaView style={styles.container}>
      <Text variant="displayMedium" style={{ fontWeight: "bold" }}>
        ¡Hola!
      </Text>
      <Text variant="displaySmall">¡Que gusto verte!</Text>
      <Formik
        initialValues={{ email: "", password: "" }}
        onSubmit={(values, actions) => {
          handleSubmit(values, actions.resetForm);
        }}
      >
        {({ handleChange, handleBlur, handleSubmit, values }) => (
          <View style={styles.form}>
            <TextInput
              label="Correo electrónico"
              value={values.email}
              onChangeText={handleChange("email")}
              onBlur={handleBlur("email")}
              style={styles.input}
              keyboardType="email-address"
              left={<TextInput.Icon icon="email" />}
            />
            <TextInput
              label="Contraseña"
              value={values.password}
              onChangeText={handleChange("password")}
              onBlur={handleBlur("password")}
              style={styles.input}
              secureTextEntry={hidePassword}
              left={<TextInput.Icon icon="lock" />}
              right={
                <TextInput.Icon
                  icon={hidePassword ? "eye" : "eye-off"}
                  onPress={() => handleHidePassword()}
                />
              }
            />
            <Button
              mode="contained"
              onPress={() => handleSubmit()}
              style={styles.button}
            >
              Iniciar Sesión
            </Button>
          </View>
        )}
      </Formik>
    </SafeAreaView>
  );
};

export default LoginScreen;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    alignItems: "center",
    gap: 20,
  },
  button: {
    width: "100%",
  },
  logo: {
    width: 350,
    height: 350,
  },
  form: {
    width: "100%",
    padding: 20,
    alignItems: "center",
    gap: 20,
    flex: 1,
  },
  input: {
    width: "100%",
  },
});
