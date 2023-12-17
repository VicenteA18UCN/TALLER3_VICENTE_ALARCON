import LoginScreen from "../../components/auth/LoginScreen";
import { Stack } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail } from "../../store/userSlice";
import { useRouter } from "expo-router";

const Login = () => {
  return (
    <>
      <Stack.Screen options={{ headerShown: true, title: "Iniciar sesión" }} />
      <LoginScreen />
    </>
  );
};

export default Login;
