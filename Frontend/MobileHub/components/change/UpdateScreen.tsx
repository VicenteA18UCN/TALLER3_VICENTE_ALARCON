import { View, StyleSheet, Image } from "react-native";
import { Text, ActivityIndicator, TextInput, Button } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { useRouter } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail } from "../../store/userSlice";
import Toast from "react-native-root-toast";
import { Formik } from "formik";
import { ChangePwd } from "../../models/ChangePwd";

const style = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    paddingTop: 0,
    alignItems: "center",
    gap: 20,
    backgroundColor: "#f0f0f0",
  },
  card: {
    width: "100%",
    backgroundColor: "#fff",
    marginTop: 15,
  },
  button: {
    width: "100%",
    marginTop: 20,
  },
  scrollView: {
    width: "100%",
    margin: 0,
    padding: 0,
    gap: 20,
    flex: 1,
  },
});

const UpdateScreen = () => {
  const router = useRouter();
  const email = useSelector(selectEmail);

  const handleSubmit = (data: ChangePwd) => {
    if (
      data.currentPassword === "" ||
      data.newPassword === "" ||
      data.confirmNewPassword === ""
    ) {
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
    } else if (data.newPassword !== data.confirmNewPassword) {
      Toast.show("¡Las contraseñas no coinciden!", {
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
    agent.Auth.password(email, data)
      .then((response) => {
        console.log(response);
        Toast.show("¡Contraseña cambiada!", {
          duration: Toast.durations.LONG,
          position: Toast.positions.BOTTOM,
          shadow: true,
          animation: true,
          hideOnPress: true,
          delay: 0,
          containerStyle: {
            backgroundColor: "#4BB543",
          },
        });
        router.push("/(drawer)/repos/repository");
      })
      .catch((error) => {
        let errorDefault: string = "Ha ocurrido un error. Intente nuevamente.";
        switch (error.status) {
          case 400:
            if (error.data == "Invalid Credentials") {
              errorDefault = "La contraseña actual es incorrecta.";
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

  return (
    <SafeAreaView style={style.container}>
      <Text variant="headlineSmall">¿Deseas cambiar contraseña?</Text>
      <Formik
        initialValues={{
          currentPassword: "",
          newPassword: "",
          confirmNewPassword: "",
        }}
        onSubmit={(values) => handleSubmit(values)}
      >
        {({ handleChange, handleBlur, handleSubmit, values }) => (
          <View style={styles.form}>
            <TextInput
              label="Contraseña actual"
              value={values.currentPassword}
              style={styles.input}
              onChangeText={handleChange("currentPassword")}
              onBlur={handleBlur("currentPassword")}
              secureTextEntry={true}
            />
            <TextInput
              label="Contraseña nueva"
              value={values.newPassword}
              style={styles.input}
              onChangeText={handleChange("newPassword")}
              onBlur={handleBlur("newPassword")}
              secureTextEntry={true}
            />
            <TextInput
              label="Confirmar contraseña nueva"
              value={values.confirmNewPassword}
              style={styles.input}
              onChangeText={handleChange("confirmNewPassword")}
              onBlur={handleBlur("confirmNewPassword")}
              secureTextEntry={true}
            />
            <Button
              mode="contained"
              onPress={() => handleSubmit()}
              style={styles.button}
            >
              Cambiar contraseña
            </Button>
          </View>
        )}
      </Formik>
    </SafeAreaView>
  );
};

export default UpdateScreen;

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
