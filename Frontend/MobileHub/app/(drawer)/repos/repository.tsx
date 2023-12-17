import { Drawer } from "expo-router/drawer";
import ReposScreen from "../../../components/repos/ReposScreen";
import { Stack } from "expo-router";
import { DrawerToggleButton } from "@react-navigation/drawer";
import { View } from "react-native";
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
