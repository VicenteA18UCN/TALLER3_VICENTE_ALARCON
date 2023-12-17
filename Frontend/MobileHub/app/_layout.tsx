import { PaperProvider, MD3LightTheme as Theme } from "react-native-paper";
import HomeScreen from "../components/HomeScreen";
import { SafeAreaProvider } from "react-native-safe-area-context";
import { Slot, Stack } from "expo-router";
import { Provider } from "react-redux";
import { store, persistor } from "../store/store";
import { PersistGate } from "redux-persist/integration/react";

const theme = {
  ...Theme,
  colors: {
    ...Theme.colors,
    primary: "#FCAF43",
    accent: "#FCAF43",
  },
};

const HomeLayout = () => {
  return (
    <Provider store={store}>
      <PersistGate persistor={persistor}>
        <PaperProvider theme={theme}>
          <SafeAreaProvider>
            <Stack screenOptions={{ headerShown: false }} />
          </SafeAreaProvider>
        </PaperProvider>
      </PersistGate>
    </Provider>
  );
};

export default HomeLayout;
