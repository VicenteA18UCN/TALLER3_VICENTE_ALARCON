import { Stack } from "expo-router";
import HomeScreen from "../components/HomeScreen";

const Index = () => {
  return (
    <>
      <Stack.Screen options={{ headerShown: true, title: "MobileHub" }} />
      <HomeScreen />
    </>
  );
};

export default Index;
