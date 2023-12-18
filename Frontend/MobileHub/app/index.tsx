import { Stack } from "expo-router";
import HomeScreen from "../components/HomeScreen";

/**
 * Componente funcional que representa la pantalla principal.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la pantalla principal.
 */
const Index = () => {
  return (
    <>
      <Stack.Screen
        options={{
          headerShown: true,
          title: "MobileHub",
          headerBackTitleVisible: false,
          headerBackVisible: false,
        }}
      />
      <HomeScreen />
    </>
  );
};

export default Index;
