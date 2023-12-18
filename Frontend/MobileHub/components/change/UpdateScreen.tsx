import { View, StyleSheet, ScrollView } from "react-native";
import { Text, TextInput, Button, Checkbox } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { useRouter } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail } from "../../store/userSlice";
import Toast from "react-native-root-toast";
import { Formik } from "formik";
import { ChangePwd } from "../../models/ChangePwd";

/**
 * Componente para la pantalla de cambio de contraseña
 * @component
 */
const UpdateScreen = () => {
  const router = useRouter();
  const email = useSelector(selectEmail);
  const [checked, setChecked] = React.useState<boolean>(false);

  /**
   * Función que se ejecuta al enviar el formulario
   * @param data Datos del formulario
   * @returns {void}
   */
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
    <SafeAreaView style={styles.container}>
      <Text variant="headlineSmall">¿Deseas cambiar contraseña?</Text>
      <ScrollView style={styles.scrollView}>
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
                secureTextEntry={!checked}
              />
              <TextInput
                label="Contraseña nueva"
                value={values.newPassword}
                style={styles.input}
                onChangeText={handleChange("newPassword")}
                onBlur={handleBlur("newPassword")}
                secureTextEntry={!checked}
              />
              <TextInput
                label="Confirmar contraseña nueva"
                value={values.confirmNewPassword}
                style={styles.input}
                onChangeText={handleChange("confirmNewPassword")}
                onBlur={handleBlur("confirmNewPassword")}
                secureTextEntry={!checked}
              />
              <View style={{ flexDirection: "row", alignItems: "center" }}>
                <Text variant="labelLarge">Mostrar contraseñas</Text>
                <Checkbox
                  status={checked ? "checked" : "unchecked"}
                  onPress={() => {
                    setChecked(!checked);
                  }}
                ></Checkbox>
              </View>
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
      </ScrollView>
    </SafeAreaView>
  );
};

export default UpdateScreen;

/**
 * Estilos de la pantalla de inicio
 */
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
    backgroundColor: "#ffffff",
  },
  scrollView: {
    width: "100%",
  },
});
