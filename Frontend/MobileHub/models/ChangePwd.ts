/**
 * Modelo del cambio de contraseña
 */
export interface ChangePwd {
    currentPassword: string;
    newPassword: string;
    confirmNewPassword: string;
  }