import { useDispatch } from "react-redux";
import { logout } from "../../../store/userSlice";
import { useRouter } from "expo-router";
import { useEffect } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";
import React from "react";
import { ActivityIndicator, Text } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import { StyleSheet } from "react-native";

/**
 * Componente funcional que representa la página de cierre de sesión.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la página de cierre de sesión.
 */
const SignOff = () => {
  const dispatch = useDispatch();
  const route = useRouter();
  const [isLoading, setIsLoading] = React.useState<boolean>(true);

  /**
   * Efecto secundario que realiza la acción de cierre de sesión, elimina el token almacenado y redirige a la pantalla principal.
   * @function
   * @sideeffect
   */
  useEffect(() => {
    dispatch(logout());
    AsyncStorage.removeItem("token");
    setTimeout(() => {
      setIsLoading(false);
      route.replace("/");
      dispatch(logout());
    }, 3000);
  }, []);

  /**
   * Renderiza un indicador de carga mientras se realiza el cierre de sesión.
   */
  if (isLoading)
    return (
      <SafeAreaView style={styles.container}>
        <Text variant="displaySmall">Cerrando sesión...</Text>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );
};

export default SignOff;

/**
 * Estilos para el componente SignOff.
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
