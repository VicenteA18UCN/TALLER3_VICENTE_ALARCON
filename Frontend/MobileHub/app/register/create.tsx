import RegisterScreen from "../../components/register/RegisterScreen";
import { Stack } from "expo-router";
const Register = () => {
  /**
   * Componente funcional que representa la página de registro.
   * @function
   * @returns {JSX.Element} - Elemento JSX que representa la página de registro.
   */
  return (
    <>
      <Stack.Screen
        options={{
          title: "Registro",
          headerShown: true,
          headerBackButtonMenuEnabled: true,
        }}
      />
      <RegisterScreen />
    </>
  );
};

export default Register;
