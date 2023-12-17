import { useDispatch } from "react-redux";
import { logout } from "../../../store/userSlice";
import { useRouter } from "expo-router";
import { useEffect } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";
import React from "react";
import { ActivityIndicator, Text } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import { StyleSheet } from "react-native";

const SignOff = () => {
  const dispatch = useDispatch();
  const route = useRouter();
  const [isLoading, setIsLoading] = React.useState<boolean>(true);

  useEffect(() => {
    dispatch(logout());
    AsyncStorage.removeItem("token");
    setTimeout(() => {
      setIsLoading(false);
      route.replace("/");
    }, 3000);
  }, []);

  if (isLoading)
    return (
  
      <SafeAreaView style={styles.container}>
        <Text variant="displaySmall">Cerrando sesión...</Text>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );
};

export default SignOff;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    alignItems: "center",
    gap: 20,
  },
});
