import { View, StyleSheet, Image } from "react-native";
import { Button, Text, Card, ActivityIndicator } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { Repository } from "../../models/Repository";
import { ScrollView } from "react-native-gesture-handler";
import { Link, useLocalSearchParams } from "expo-router";
import { useRouter } from "expo-router";
import { useNavigation } from "expo-router";
import { useSelector } from "react-redux";
import { selectEmail, selectToken } from "../../store/userSlice";

const style = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    paddingTop: 0,
    alignItems: "center",
    gap: 20,
    backgroundColor: "#f0f0f0",
  },
  card: {
    width: "100%",
    backgroundColor: "#fff",
    marginTop: 15,
  },
  button: {
    width: "100%",
    marginTop: 20,
  },
  scrollView: {
    width: "100%",
    margin: 0,
    padding: 0,
    gap: 20,
    flex: 1,
  },
});

const ReposScreen = () => {
  const [repo, setRepo] = React.useState<Repository[]>([]);
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const router = useRouter();
  const navigation = useNavigation();
  const email = useSelector(selectEmail);
  console.log(email);
  const token = useSelector(selectToken);
  console.log(token);

  React.useEffect(() => {
    setIsLoading(true);
    getRepository();
  }, []);

  const getRepository = () => {
    agent.Repository.list()
      .then((response) => {
        console.log(response);
        setRepo(response);
        console.log(repo);
      })
      .catch((error) => {
        console.log(error);
      })
      .finally(() => {
        setIsLoading(false);
      });
  };

  const handlePress = (name: string) => {
    router.push({
      pathname: `/(drawer)/repos/commits/commit`,
      params: { name: name },
    });
  };

  if (isLoading)
    return (
      <SafeAreaView style={style.container}>
        <ActivityIndicator animating={true} size={"large"} />
      </SafeAreaView>
    );

  return (
    <SafeAreaView style={style.container}>
      <ScrollView style={style.scrollView}>
        {repo.map((repo, index) => (
          <Card style={style.card} key={index}>
            <Card.Title title={repo.name} titleVariant={"headlineMedium"} />
            <Card.Content>
              <Text variant="bodyMedium">
                Creado el: {repo.createdAt.split("T")[0]}
              </Text>
              <Text variant="bodyMedium">
                Actualizado el: {repo.updatedAt.split("T")[0]}
              </Text>
              <Text variant="bodyMedium">
                Cantidad de Commits: {repo.commitCount}
              </Text>
            </Card.Content>
            <Card.Actions>
              <Button mode="contained" onPress={() => handlePress(repo.name)}>
                Ver commits
              </Button>
            </Card.Actions>
          </Card>
        ))}
      </ScrollView>
    </SafeAreaView>
  );
};

export default ReposScreen;
