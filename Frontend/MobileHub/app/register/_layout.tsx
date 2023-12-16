import { Slot, router } from "expo-router";
import { Appbar } from "react-native-paper";

const handleBack = () => {
  router.back();
  console.log("Pressed");
};

const RegisterLayout = () => {
  return (
    <>
      <Appbar.Header>
        <Appbar.BackAction onPress={handleBack} />
        <Appbar.Content title="Regístrate" />
      </Appbar.Header>
      <Slot />
    </>
  );
};

export default RegisterLayout;
