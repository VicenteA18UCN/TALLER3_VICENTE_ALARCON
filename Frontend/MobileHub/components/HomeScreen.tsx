import { Link } from "expo-router";
import { View, StyleSheet, Image } from "react-native";
import { Button, Text } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";

/**
 * Componente que renderiza la pantalla de inicio
 * @component
 */
const HomeScreen = () => {
  return (
    <SafeAreaView style={styles.container}>
      <Text variant="displayMedium" style={{ fontWeight: "bold" }}>
        ¡Bienvenid@!
      </Text>
      <Image
        source={require("../assets/images/MobileHub.png")}
        style={styles.logo}
      />
      <Link href="/auth/login" asChild>
        <Button mode="contained" style={styles.button}>
          Iniciar Sesión
        </Button>
      </Link>
      <Link href="/register/create" asChild>
        <Button mode="outlined" style={styles.button}>
          Regístrarme
        </Button>
      </Link>
    </SafeAreaView>
  );
};

export default HomeScreen;

/**
 * Estilos de la pantalla de inicio
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
});
