import { View, StyleSheet, Image } from "react-native";
import {
  Button,
  Text,
  Appbar,
  TextInput,
  Card,
  ActivityIndicator,
} from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { Repository } from "../../models/Repository";
import { ScrollView } from "react-native-gesture-handler";
import Index from "../../app/index";

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

  React.useEffect(() => {
    setIsLoading(true);
    getRepository();
  }, []);

  const getRepository = () => {
    agent.Repository.list()
      .then((response) => {
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
          <Card style={style.card}>
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
              <Button mode="contained">Ver commits</Button>
            </Card.Actions>
          </Card>
        ))}
      </ScrollView>
    </SafeAreaView>
  );
};

export default ReposScreen;
