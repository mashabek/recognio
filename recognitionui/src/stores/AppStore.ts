import {defineStore} from 'pinia'

export type User = {
    username : string,
    access_token : string
}
export interface AppState {
    user : null | User,
    tokens : {}
};

export const useAppStore = defineStore({id : 'root', 
    state: () : AppState => ({tokens: {}, user: null}),
    getters: {
        getCurrentUser(state : AppState) : User | null {
            return state.user;
        },
        getAccessToken : (state : AppState) => state.tokens
    },
    actions: { 
        setCurrentUser(user : User) {
            this.user = user;
        }
    }
});
