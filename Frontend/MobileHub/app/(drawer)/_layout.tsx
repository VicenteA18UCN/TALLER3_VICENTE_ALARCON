import { Drawer } from "expo-router/drawer";
import { Icon } from "react-native-paper";
import React from "react";

/**
 * Componente funcional que representa el diseño del menú deslizante (Drawer) con opciones de navegación.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa el menú deslizante.
 */
const DrawerLayout = () => {
  return (
    <>
      <Drawer
        screenOptions={{
          headerShown: false,
        }}
      >
        <Drawer.Screen
          name="repos"
          options={{
            drawerLabel: "Repositorios",
            title: "Repositorios",
            drawerIcon: ({ color, size, focused }) => (
              <Icon source="book" color={color} size={size} />
            ),
            drawerActiveTintColor: "#FCAF43",
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
            drawerActiveTintColor: "#FCAF43",
          }}
        />
        <Drawer.Screen
          name="change"
          options={{
            drawerLabel: "Cambiar contraseña",
            title: "Cambiar contraseña",
            drawerIcon: ({ color, size, focused }) => (
              <Icon source="lock" color={color} size={size} />
            ),
            drawerActiveTintColor: "#FCAF43",
          }}
        />
        <Drawer.Screen
          name="logout"
          options={{
            drawerLabel: "Cerrar Sesión",
            title: "Cerrar Sesión",
            drawerIcon: ({ color, size, focused }) => (
              <Icon source="logout" color="red" size={size} />
            ),
            drawerLabelStyle: { color: "red" },
          }}
        />
      </Drawer>
    </>
  );
};

export default DrawerLayout;
