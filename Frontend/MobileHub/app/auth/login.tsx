import LoginScreen from "../../components/auth/LoginScreen";
import { Stack } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail } from "../../store/userSlice";
import { useRouter } from "expo-router";
import React from "react";
import { SafeAreaView } from "react-native-safe-area-context";
import { ActivityIndicator, Text } from "react-native-paper";
import { StyleSheet } from "react-native";

/**
 * Componente funcional que representa la página de inicio de sesión.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la página de inicio de sesión.
 */
const Login = () => {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const router = useRouter();
  const email = useSelector(selectEmail);

  /**
   * Efecto secundario que redirige a la página de repositorios si el usuario ya está autenticado.
   * @function
   * @sideeffect
   */
  React.useEffect(() => {
    if (email) {
      setIsLoading(true);
      setTimeout(() => {
        router.push("/(drawer)/repos/repository");
      }, 2000);
    }
  }, []);

  /**
   * Renderiza la pantalla de carga si se está iniciando sesión.
   */
  if (isLoading)
    return (
      <SafeAreaView style={styles.container}>
        <Text variant="displaySmall">Iniciando sesión...</Text>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );

  return (
    <>
      <Stack.Screen options={{ headerShown: true, title: "Iniciar sesión" }} />
      <LoginScreen />
    </>
  );
};

export default Login;

/**
 * Estilos para el componente Login.
 * @constant {object}
 */
const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    alignItems: "center",
    gap: 20,
  },
});
