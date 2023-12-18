import { Drawer } from "expo-router/drawer";
import ReposScreen from "../../../components/repos/ReposScreen";
import { DrawerToggleButton } from "@react-navigation/drawer";

/**
 * Componente funcional que representa la página de repositorios.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la página de repositorios.
 */
const Repos = () => {
  return (
    <>
      <Drawer.Screen
        options={{
          headerShown: true,
          title: "Repositorios",
          headerLeft: () => <DrawerToggleButton />,
        }}
      />
      <ReposScreen />
    </>
  );
};

export default Repos;
