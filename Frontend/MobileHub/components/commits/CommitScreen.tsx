import { View, StyleSheet, Image } from "react-native";
import {
  Button,
  Text,
  Card,
  ActivityIndicator,
  Divider,
} from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";
import React from "react";
import { ScrollView } from "react-native-gesture-handler";
import { Commit } from "../../models/Commit";
import { useNavigation } from "expo-router";

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

interface Props {
  commitName: string;
}

const CommitScreen = ({ commitName }: Props) => {
  const [commit, setcommit] = React.useState<Commit[]>([]);
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const navigation = useNavigation();
  React.useEffect(() => {
    setIsLoading(true);
    getCommits(commitName);
  }, []);

  const getCommits = (name: string) => {
    agent.Commit.list(name)
      .then((response) => {
        setcommit(response);
        console.log(commit);
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
        {commit.map((commit, index) => (
          <Card style={style.card} key={index}>
            <Card.Title
              title={commit.message}
              titleVariant={"headlineSmall"}
              titleNumberOfLines={4}
              style={{ marginTop: 4, marginBottom: 4 }}
            />
            <Card.Content>
              <Divider style={{ width: "100%", marginBottom: 4 }} />
              <Text variant="bodyMedium">
                Fecha: {commit.date.split("T")[0]}
              </Text>
              <Text variant="bodyMedium">
                Hora: {commit.date.split("T")[1].split("+")[0]}
              </Text>
              <Text variant="bodyMedium">Usuario: {commit.user}</Text>
              <Image
                source={{ uri: commit.avatarUrl }}
                style={{ width: 50, height: 50, marginLeft: "auto" }}
              />
            </Card.Content>
          </Card>
        ))}
      </ScrollView>
    </SafeAreaView>
  );
};

export default CommitScreen;
