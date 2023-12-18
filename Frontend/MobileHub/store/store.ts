import { configureStore, combineReducers} from "@reduxjs/toolkit";
import { userSlice } from "./userSlice";
import { persistReducer, persistStore } from "redux-persist";
import AsyncStorage from "@react-native-async-storage/async-storage";

/**
 * Configuración de persistencia para el almacenamiento Redux.
 * @constant {object}
 * @property {string} key - Clave para la persistencia.
 * @property {AsyncStorage} storage - Almacenamiento para la persistencia.
 */
const persistConfig = {
    key: 'root',
    storage: AsyncStorage,
};

/**
 * Reductor combinado para el almacenamiento Redux.
 * @constant {object}
 * @property {object} user - Reductor para la porción de estado del usuario.
 */
const rootReducer = combineReducers({
    user: userSlice.reducer,
});

/**
 * Reductor combinado con persistencia aplicada.
 * @constant {object}
 */
const persistedReducer = persistReducer(persistConfig, rootReducer);

/**
 * Almacenamiento configurado con persistencia y middleware personalizado.
 * @constant {object}
 * @property {function} reducer - Reductor raíz con persistencia.
 * @property {function} middleware - Middleware personalizado para el almacenamiento.
 */
export const store = configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),

});
/**
 * Persistor asociado al almacenamiento Redux configurado.
 * @constant {object}
 */
export const persistor = persistStore(store);
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;