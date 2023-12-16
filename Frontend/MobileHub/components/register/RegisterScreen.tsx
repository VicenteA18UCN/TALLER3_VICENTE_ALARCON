import { Formik } from "formik";
import { View, StyleSheet, Image } from "react-native";
import { Button, Text, Appbar, TextInput } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";

interface props {
  fullname: string;
  email: string;
  rut: string;
  birthday: string;
}

const RegisterScreen = () => {
  const handleSubmit = (data: props) => {
    console.log(data);
    const birthday = parseInt(data.birthday);
    agent.Auth.register(data.fullname, data.email, birthday, data.rut)
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <SafeAreaView style={styles.container}>
      <Text variant="displayMedium">¡Bienvenid@!</Text>
      <Formik
        initialValues={{
          email: "",
          fullname: "",
          rut: "",
          birthday: "",
        }}
        onSubmit={(values) => handleSubmit(values)}
      >
        {({ handleChange, handleBlur, handleSubmit, values }) => (
          <View style={styles.form}>
            <TextInput
              label="Nombre completo"
              value={values.fullname}
              onChangeText={handleChange("fullname")}
              onBlur={handleBlur("fullname")}
              style={styles.input}
            />
            <TextInput
              label="Rut"
              value={values.rut}
              onChangeText={handleChange("rut")}
              onBlur={handleBlur("rut")}
              style={styles.input}
            />
            <TextInput
              label="Correo electrónico"
              value={values.email}
              onChangeText={handleChange("email")}
              onBlur={handleBlur("email")}
              style={styles.input}
            />
            <TextInput
              label="Año de nacimiento"
              value={values.birthday.toString()}
              onChangeText={handleChange("birthday")}
              onBlur={handleBlur("birthday")}
              style={styles.input}
              keyboardType="numeric"
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
    </SafeAreaView>
  );
};

export default RegisterScreen;

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
  },
  input: {
    marginBottom: 20,
  },
});
