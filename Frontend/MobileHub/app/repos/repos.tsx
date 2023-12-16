import ReposScreen from "../../components/repos/ReposScreen";
import { Stack } from "expo-router";
const Repos = () => {
  return (
    <>
      <Stack.Screen
        options={{ headerShown: true, title: "Mis repositorios" }}
      />
      <ReposScreen />
    </>
  );
};

export default Repos;
