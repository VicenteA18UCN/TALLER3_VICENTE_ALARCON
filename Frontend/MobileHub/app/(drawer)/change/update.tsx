import { Drawer } from "expo-router/drawer";
import { DrawerToggleButton } from "@react-navigation/drawer";
import UpdateScreen from "../../../components/change/UpdateScreen";

/**
 * Componente funcional que representa la página de cambio de contraseña.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la página de edición.
 */
const Edit = () => {
  return (
    <>
      <Drawer.Screen
        options={{
          headerShown: true,
          title: "Cambiar contraseña",
          headerLeft: () => <DrawerToggleButton />,
        }}
      />
      <UpdateScreen />
    </>
  );
};

export default Edit;
