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

interface props {
  email: string;
  password: string;
}

const LoginScreen = () => {
  const [hidePassword, setHidePassword] = React.useState(true);
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const router = useRouter();
  const dispatch = useDispatch();

  const email = useSelector(selectEmail);

  React.useEffect(() => {
    if (email) {
      setIsLoading(true);
      setTimeout(() => {
        router.push("/(drawer)/repos/repository");
      }, 2000);
    }
  }, [email]);

  const handleSubmit = (data: props) => {
    console.log(data);
    console.log(data.email);
    agent.Auth.login(data.email, data.password)
      .then((response) => {
        console.log(response);
        dispatch(login(response.token));
        router.push("/(drawer)/repos/repository");
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleHidePassword = () => {
    setHidePassword(!hidePassword);
  };

  if (isLoading)
    return (
      <SafeAreaView style={styles.container}>
        <Text variant="displaySmall">Iniciando sesión...</Text>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );

  return (
    <SafeAreaView style={styles.container}>
      <Text variant="displayMedium">¡Hola!</Text>
      <Text variant="displaySmall">¡Que gusto verte!</Text>
      <Formik
        initialValues={{ email: "", password: "" }}
        onSubmit={(values) => handleSubmit(values)}
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