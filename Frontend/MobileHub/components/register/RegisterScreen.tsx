import { Formik } from "formik";
import { View, StyleSheet, ScrollView } from "react-native";
import { Button, Text, TextInput } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import { useRouter } from "expo-router";
import Toast from "react-native-root-toast";
import { format, clean } from "rut.js";

/**
 * Interfaz para los datos del formulario
 */
interface props {
  fullname: string;
  email: string;
  rut: string;
  birthday: string;
}

/**
 * Componente para la pantalla de registro
 * @component
 */
const RegisterScreen = () => {
  const router = useRouter();

  /**
   * Función que se ejecuta al enviar el formulario
   * @param data Datos del formulario
   * @param resetForm Función para resetear el formulario
   * @returns {void}
   */
  const handleSubmit = (data: props, resetForm: any) => {
    const birthday = parseInt(data.birthday);
    const rut = clean(data.rut);
    if (
      data.fullname === "" ||
      data.email === "" ||
      data.rut === "" ||
      data.birthday === ""
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
    }
    agent.Auth.register(data.fullname, data.email, birthday, format(rut))
      .then((response) => {
        router.push("/");
        Toast.show("¡Registro exitoso!", {
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
        resetForm();
      })
      .catch((error) => {
        let errorMessage: string = "Ha ocurrido un error. Intente nuevamente.";
        switch (error.data.status) {
          case 400:
            if (error.data.errors?.Fullname) {
              if (
                error.data.errors.Fullname.includes(
                  "The fullname must be at least 10 characters"
                )
              ) {
                console.log(error.data.errors.Fullname);
                errorMessage = "El nombre debe tener al menos 10 caracteres.";
              } else if (
                error.data.errors.Fullname.includes(
                  "The fullname must be less than 150 characters"
                )
              ) {
                errorMessage = "El nombre debe tener menos de 150 caracteres.";
              }
            } else if (error.data.errors?.Rut) {
              if (error.data.errors.Rut.includes("The rut is not valid")) {
                errorMessage = "El rut no es válido.";
              }
            } else if (error.data.errors?.Birthday) {
              if (
                error.data.errors.Birthday.includes("The birthday is not valid")
              ) {
                errorMessage = "El año de nacimiento no es válido.";
              }
            } else if (error.data.errors?.Email) {
              if (error.data.errors.Email.includes("The email is not valid")) {
                errorMessage = "El correo electrónico no es válido.";
              }
            }
            break;
          case 500:
            errorMessage = "Ha ocurrido un error. Intente nuevamente.";
            break;
        }
        if (error.data === "Email already exists") {
          errorMessage = "El correo electrónico ya está registrado.";
        } else if (error.data === "Rut already exists") {
          errorMessage = "El rut ya está registrado.";
        }
        Toast.show(errorMessage, {
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
      <Text variant="displayMedium" style={{ fontWeight: "bold" }}>
        ¡Regístrate!
      </Text>
      <Text variant="displaySmall">¡Es gratis!</Text>
      <ScrollView style={styles.form}>
        <Formik
          initialValues={{
            email: "",
            fullname: "",
            rut: "",
            birthday: "",
          }}
          onSubmit={(values, actions) =>
            handleSubmit(values, actions.resetForm)
          }
        >
          {({ handleChange, handleBlur, handleSubmit, values }) => (
            <View style={styles.form}>
              <TextInput
                label="Nombre completo"
                value={values.fullname}
                onChangeText={handleChange("fullname")}
                onBlur={handleBlur("fullname")}
                style={styles.input}
                left={<TextInput.Icon icon="account" />}
              />
              <TextInput
                label="Año de nacimiento"
                value={values.birthday.toString()}
                onChangeText={handleChange("birthday")}
                onBlur={handleBlur("birthday")}
                style={styles.input}
                keyboardType="numeric"
                left={<TextInput.Icon icon="calendar" />}
              />
              <TextInput
                label="Rut"
                placeholder="Ej: 12.345.678-9"
                value={values.rut !== "" ? format(values.rut) : ""}
                onChangeText={handleChange("rut")}
                onBlur={handleBlur("rut")}
                left={<TextInput.Icon icon="account-details" />}
                style={styles.input}
              />
              <TextInput
                label="Correo electrónico"
                value={values.email}
                onChangeText={handleChange("email")}
                onBlur={handleBlur("email")}
                style={styles.input}
                keyboardType="email-address"
                left={<TextInput.Icon icon="email" />}
              />

              <Button
                mode="contained"
                onPress={() => handleSubmit()}
                style={styles.button}
              >
                Registrarme
              </Button>
            </View>
          )}
        </Formik>
      </ScrollView>
    </SafeAreaView>
  );
};

export default RegisterScreen;

/**
 * Estilos de la pantalla de registro
 */
const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    alignItems: "center",
    gap: 20,
    backgroundColor: "#fff",
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
  },
  input: {
    marginBottom: 20,
    backgroundColor: "#ffffff",
  },
});
