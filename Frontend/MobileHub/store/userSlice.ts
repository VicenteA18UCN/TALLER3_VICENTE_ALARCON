import { createSlice } from "@reduxjs/toolkit";
import {jwtDecode} from "jwt-decode";
import type { PayloadAction } from '@reduxjs/toolkit';
import "core-js/stable/atob";

/**
 * Interfaz que representa la carga útil del token JWT.
 * @typedef {object} JwtPayload
 * @property {string} nameid - Identificador del nombre en la carga útil del token.
 * @property {number} nbf - Tiempo antes de que el token sea válido.
 * @property {number} exp - Tiempo de expiración del token.
 * @property {number} iat - Tiempo en que se emitió el token.
 */
interface JwtPayload 
{
    nameid:string,
    nbf:number,
    exp:number,
    iat:number,
}

/**
 * Estado inicial de la porción de estado del usuario.
 * @typedef {object} UserState
 * @property {string | null} email - Correo electrónico del usuario.
 * @property {string | null} token - Token de autenticación del usuario.
 */
export interface UserState 
{
    email: string | null,
    token: string | null,
}

/**
 * Estado inicial de la porción de estado del usuario.
 * @type {UserState}
 */
const initialState: UserState = {
    email: null,
    token: null,
};

/**
 * Reductor y acciones relacionadas con la gestión del usuario.
 * @type {object}
 */
export const userSlice = createSlice({
    name: 'account',
    initialState,
    reducers: {
        /**
         * Acción para realizar el inicio de sesión del usuario.
         * @function
         * @param {UserState} state - Estado actual de la porción de estado del usuario.
         * @param {PayloadAction<string>} action - Acción con la carga útil del token de autenticación.
         */
        login(state,action:PayloadAction<string>)
        {
            const payload = jwtDecode<JwtPayload>(action.payload);
            state.email = payload.nameid;
            state.token = action.payload;
        },
        /**
         * Acción para realizar el cierre de sesión del usuario.
         * @function
         * @param {UserState} state - Estado actual de la porción de estado del usuario.
         */
        logout(state)
        {
            state.email = null;
            state.token = null;
        },
    },
});

/**
 * Selector para obtener el correo electrónico del usuario desde el estado de Redux.
 * @function
 * @param {any} state - Estado de Redux.
 * @returns {string | null} - Correo electrónico del usuario.
 */
export const selectEmail = (state: any) => state.user.email;

/**
 * Selector para obtener el token de autenticación del usuario desde el estado de Redux.
 * @function
 * @param {any} state - Estado de Redux.
 * @returns {string | null} - Token de autenticación del usuario.
 */
export const selectToken = (state:any) => state.user.token;

/**
 * Acciones de la porción de estado del usuario.
 * @type {object}
 */
export const { login, logout } = userSlice.actions;