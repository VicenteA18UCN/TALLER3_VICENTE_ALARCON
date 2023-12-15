import { View, StyleSheet, Image } from "react-native";
import { Button, Text } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";

const HomeScreen = () => {
  return (
    <SafeAreaView style={styles.container}>
      <Text variant="displayMedium">¡Bienvenid@!</Text>
      <Image
        source={require("../assets/images/MobileHub.png")}
        style={styles.logo}
      />
      <Button
        mode="contained"
        onPress={() => console.log("Pressed")}
        style={styles.button}
      >
        Iniciar Sesión
      </Button>
      <Button
        mode="outlined"
        onPress={() => console.log("Pressed")}
        style={styles.button}
      >
        Regístrarme
      </Button>
    </SafeAreaView>
  );
};

export default HomeScreen;

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
});
