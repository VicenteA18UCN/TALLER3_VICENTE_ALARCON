import { Drawer } from "expo-router/drawer";
import { useDispatch } from "react-redux";
import { Icon, MD3Colors } from "react-native-paper";

const DrawerLayout = () => {
  return (
    <>
      <Drawer screenOptions={{ headerShown: false }}>
        <Drawer.Screen
          name="repos"
          options={{
            drawerLabel: "Repositorios",
            title: "Repositorios",
            drawerIcon: ({ color, size, focused }) => (
              <Icon source="book" color={color} size={size} />
            ),
          }}
        />
        <Drawer.Screen
          name="edit"
          options={{
            drawerLabel: "Editar perfil",
            title: "Editar perfil",
            drawerIcon: ({ color, size, focused }) => (
              <Icon source="account" color={color} size={size} />
            ),
          }}
        />
      </Drawer>
    </>
  );
};

export default DrawerLayout;
