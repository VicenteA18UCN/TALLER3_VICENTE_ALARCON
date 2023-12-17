import { DrawerToggleButton } from "@react-navigation/drawer";
import { Drawer } from "expo-router/drawer";

const DrawerLayout = () => {
  return (
    <>
      <Drawer screenOptions={{ headerShown: false }}>
        <Drawer.Screen
          name="repos"
          options={{
            drawerLabel: "Repositorios",
            title: "Repositorios",
          }}
        />
        <Drawer.Screen
          name="edit"
          options={{
            drawerLabel: "Editar perfil",
            title: "Editar perfil",
          }}
        />
      </Drawer>
    </>
  );
};

export default DrawerLayout;
