import { View, StyleSheet, ScrollView } from "react-native";
import { Text, ActivityIndicator, TextInput, Button } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { useRouter } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail } from "../../store/userSlice";
import { User } from "../../models/User";
import { Formik } from "formik";
import { UserUpdate } from "../../models/UserUpdate";
import Toast from "react-native-root-toast";

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

const EditScreen = () => {
  const [user, setUser] = React.useState<User>();
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const [isDisabled, setIsDisabled] = React.useState<boolean>(true);
  const router = useRouter();
  const email = useSelector(selectEmail);

  React.useEffect(() => {
    setIsLoading(true);
    getUser();
  }, []);

  const getUser = () => {
    agent.User.info(email)
      .then((response) => {
        setUser(response);
        console.log(user);
      })
      .catch((error) => {
        console.log(error);
      })
      .finally(() => {
        setIsLoading(false);
      });
  };

  const handleEdit = () => {
    setIsDisabled(!isDisabled);
  };

  const handleSubmit = (data: UserUpdate) => {
    console.log(data);
    const rut = user?.rut;
    if (!rut) return;
    agent.User.update(rut, data)
      .then((response) => {
        console.log(response);
        getUser();
        Toast.show("¡Perfil actualizado!", {
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
        setIsDisabled(true);
      })
      .catch((error) => {
        console.log(error.data);
        console.log(error.data.status);
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

  if (isLoading)
    return (
      <SafeAreaView style={style.container}>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );

  return (
    <SafeAreaView style={style.container}>
      <Text variant="headlineLarge">Información Personal</Text>
      <ScrollView style={styles.input}>
        <Formik
          initialValues={{
            fullname: user?.fullname,
            email: user?.email,
            birthday: user?.birthday?.toString(),
          }}
          onSubmit={(values) => handleSubmit(values)}
        >
          {({ handleChange, handleBlur, handleSubmit, values }) => (
            <View style={styles.form}>
              <TextInput
                label="Nombre"
                value={values.fullname}
                style={styles.input}
                left={<TextInput.Icon icon="account" />}
                disabled={isDisabled}
                onChangeText={handleChange("fullname")}
                onBlur={handleBlur("fullname")}
              />
              <TextInput
                label="Año de nacimiento"
                value={values.birthday}
                style={styles.input}
                left={<TextInput.Icon icon="calendar" />}
                disabled={isDisabled}
                onChangeText={handleChange("birthday")}
                onBlur={handleBlur("birthday")}
                keyboardType="numeric"
              />
              <TextInput
                label="Correo electrónico"
                value={values.email}
                style={styles.input}
                left={<TextInput.Icon icon="email" />}
                disabled={isDisabled}
                onChangeText={handleChange("email")}
                onBlur={handleBlur("email")}
              />

              {isDisabled ? (
                <Button
                  mode="contained"
                  onPress={handleEdit}
                  style={styles.button}
                >
                  Editar perfil
                </Button>
              ) : (
                <>
                  <Button
                    mode="contained"
                    onPress={() => handleSubmit()}
                    style={styles.button}
                  >
                    Guardar
                  </Button>
                  <Button
                    mode="outlined"
                    onPress={handleEdit}
                    style={styles.button}
                  >
                    Cancelar
                  </Button>
                </>
              )}
            </View>
          )}
        </Formik>
      </ScrollView>
    </SafeAreaView>
  );
};

export default EditScreen;

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
});
