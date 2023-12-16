import { View, StyleSheet, Image } from "react-native";
import { Button, Text, Appbar, TextInput, Card } from "react-native-paper";
import { SafeAreaView } from "react-native-safe-area-context";
import agent from "../../api/agent";

const ReposScreen = () => {
  return (
    <SafeAreaView>
      <Card>
        <Card.Title title="Repo" />
        <Card.Content>
          <Text>Repo</Text>
        </Card.Content>
      </Card>
    </SafeAreaView>
  );
};

export default ReposScreen;
