import { PaperProvider, MD3LightTheme as Theme } from "react-native-paper";
import HomeScreen from "../components/HomeScreen";
import { SafeAreaProvider } from "react-native-safe-area-context";
import { Slot } from "expo-router";

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
    <PaperProvider theme={theme}>
      <SafeAreaProvider>
        <Slot />
      </SafeAreaProvider>
    </PaperProvider>
  );
};

export default HomeLayout;
