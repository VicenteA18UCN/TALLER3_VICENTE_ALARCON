import { View, StyleSheet, Image } from "react-native";
import { Text, ActivityIndicator, TextInput, Button } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { useRouter } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail } from "../../store/userSlice";
import { User } from "../../models/User";

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

  if (isLoading)
    return (
      <SafeAreaView style={style.container}>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );

  return (
    <SafeAreaView style={style.container}>
      <Text variant="headlineLarge">Información Personal</Text>
      <TextInput
        label="Nombre"
        value={user?.fullname}
        style={styles.input}
        left={<TextInput.Icon icon="account" />}
        disabled={isDisabled}
      />
      <TextInput
        label="Correo electrónico"
        value={user?.email}
        style={styles.input}
        left={<TextInput.Icon icon="email" />}
        disabled={isDisabled}
      />
      <TextInput
        label="Año de nacimiento"
        value={user?.birthday.toString()}
        style={styles.input}
        left={<TextInput.Icon icon="cake" />}
        disabled={isDisabled}
      />
      {isDisabled ? (
        <Button mode="contained" onPress={handleEdit} style={styles.button}>
          Editar perfil
        </Button>
      ) : (
        <>
          <Button
            mode="contained"
            onPress={() => console.log("Guardar")}
            style={styles.button}
          >
            Guardar
          </Button>
          <Button mode="outlined" onPress={handleEdit} style={styles.button}>
            Cancelar
          </Button>
        </>
      )}
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
  },
});
