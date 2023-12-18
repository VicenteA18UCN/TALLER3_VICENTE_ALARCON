/**
 * Modelo del repositorio
 */
export interface Repository {
    name: string;
    createdAt: string;
    updatedAt: string;
    commitCount: number;
}