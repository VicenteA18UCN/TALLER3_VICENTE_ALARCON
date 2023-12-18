import { PaperProvider, MD3LightTheme as Theme } from "react-native-paper";
import { SafeAreaProvider } from "react-native-safe-area-context";
import { Stack } from "expo-router";
import { Provider } from "react-redux";
import { store, persistor } from "../store/store";
import { PersistGate } from "redux-persist/integration/react";
import { RootSiblingParent } from "react-native-root-siblings";

/**
 * Tema personalizado que extiende el tema MD3Light de react-native-paper.
 * @constant {object}
 * @property {object} colors - Paleta de colores personalizada.
 * @property {string} colors.primary - Color primario personalizado.
 * @property {string} colors.accent - Color de acento personalizado.
 */
const theme = {
  ...Theme,
  colors: {
    ...Theme.colors,
    primary: "#FCAF43",
    accent: "#FCAF43",
  },
};

/**
 * Componente funcional que representa la estructura principal de la pantalla de inicio.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la estructura de la pantalla de inicio.
 */
const HomeLayout = () => {
  return (
    <Provider store={store}>
      <PersistGate persistor={persistor}>
        <PaperProvider theme={theme}>
          <SafeAreaProvider>
            <RootSiblingParent>
              <Stack screenOptions={{ headerShown: false }} />
            </RootSiblingParent>
          </SafeAreaProvider>
        </PaperProvider>
      </PersistGate>
    </Provider>
  );
};

export default HomeLayout;
