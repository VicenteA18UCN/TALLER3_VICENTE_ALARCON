import { Drawer } from "expo-router/drawer";
import ReposScreen from "../../../components/repos/ReposScreen";
import { Text } from "react-native-paper";
import { DrawerToggleButton } from "@react-navigation/drawer";
import EditScreen from "../../../components/edit/EditScreen";
import UpdateScreen from "../../../components/change/UpdateScreen";

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
