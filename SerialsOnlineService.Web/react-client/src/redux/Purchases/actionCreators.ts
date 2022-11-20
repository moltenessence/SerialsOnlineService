import usersService from "../../Services/UsersService";
import tokenStorage from "../../Services/TokenStorage";
import { PurchasesActions } from "./purchasesReducer";
import { AppDispatch } from "../store";
import { setisFetching, setPurchases } from "./actions";
import purchaseService from "../../Services/PurchaseService";

export const fetchPurchases = () => {
    return async (dispatch: AppDispatch<PurchasesActions>) => {
        dispatch(setisFetching(true));
        if (tokenStorage.getUserDataFromToken() !== null) {
            const userId = await usersService.getByEmail(tokenStorage.getUserDataFromToken()?.email).then((user) => { return user.id });
            await purchaseService.getByUserId(userId).then((purchases) => {
                console.log(purchases);
                
                dispatch(setPurchases(purchases));
                dispatch(setisFetching(false));
            });
        }
    };
};