import * as React from "react";
import { Stack } from "expo-router";

/**
 * Componente funcional que representa el diseño de la pantalla de cierre de sesión.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa el diseño de la pantalla de cierre de sesión.
 */
const LogoutLayout = () => {
  return (
    <>
      <Stack screenOptions={{ title: "" }}></Stack>
    </>
  );
};

export default LogoutLayout;
