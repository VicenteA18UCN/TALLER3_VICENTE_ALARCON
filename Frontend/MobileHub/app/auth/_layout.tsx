import { Slot, router } from "expo-router";
import { Appbar } from "react-native-paper";

const handleBack = () => {
  router.back();
  console.log("Pressed");
};

const LoginLayout = () => {
  return (
    <>
      <Appbar.Header>
        <Appbar.BackAction onPress={handleBack} />
        <Appbar.Content title="Iniciar Sesión" />
      </Appbar.Header>
      <Slot />
    </>
  );
};

export default LoginLayout;
