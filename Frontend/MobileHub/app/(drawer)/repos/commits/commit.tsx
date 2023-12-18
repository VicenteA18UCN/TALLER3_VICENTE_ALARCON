import { Stack, useLocalSearchParams } from "expo-router";
import CommitScreen from "../../../../components/commits/CommitScreen";
/**
 * Tipo de parámetros de búsqueda para la página de commits.
 * @typedef {Object} ParamsSearch
 * @property {string} name - Nombre del repositorio.
 */
type ParamsSearch = {
  name: string;
};

/**
 * Componente funcional que representa la página de información sobre los commits.
 * @function
 * @returns {JSX.Element} - Elemento JSX que representa la página de información sobre los commits.
 */
const Commit = () => {
  // Obtiene los parámetros de búsqueda locales (name) desde la URL
  const { name } = useLocalSearchParams<ParamsSearch>();
  return (
    <>
      <Stack.Screen
        options={{
          title: "Información",
          headerShown: true,
          headerBackButtonMenuEnabled: true,
        }}
      />
      <CommitScreen repoName={name} />
    </>
  );
};

export default Commit;
