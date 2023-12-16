import { Drawer } from "expo-router/drawer";
import ReposScreen from "../../../components/repos/ReposScreen";
import { Text } from "react-native-paper";
import { DrawerToggleButton } from "@react-navigation/drawer";

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
      <Text>Editar</Text>
    </>
  );
};

export default Edit;
