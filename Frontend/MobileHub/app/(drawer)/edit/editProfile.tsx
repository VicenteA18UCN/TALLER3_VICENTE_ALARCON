import { Drawer } from "expo-router/drawer";
import { DrawerToggleButton } from "@react-navigation/drawer";
import EditScreen from "../../../components/edit/EditScreen";

/**
 * Componente funcional que representa la página de edición de perfil.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la página de edición de perfil.
 */
const Edit = () => {
  return (
    <>
      <Drawer.Screen
        options={{
          headerShown: true,
          title: "Editar perfil",
          headerLeft: () => <DrawerToggleButton />,
        }}
      />
      <EditScreen />
    </>
  );
};

export default Edit;
