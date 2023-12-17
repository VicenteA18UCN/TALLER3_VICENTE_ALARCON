import { useDispatch } from "react-redux";
import { logout } from "../../../store/userSlice";
import { useRouter } from "expo-router";
import { useEffect } from "react";

const SignOff = () => {
  const dispatch = useDispatch();
  const route = useRouter();

  useEffect(() => {
    dispatch(logout());
    route.replace("/");
  }, []);

  return null;
};

export default SignOff;
