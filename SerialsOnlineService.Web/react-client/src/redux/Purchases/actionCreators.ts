import usersService from "../../Services/UsersService";
import tokenStorage from "../../Services/TokenStorage";
import { PurchasesActions } from "./purchasesReducer";
import { AppDispatch } from "../store";
import { setisFetching, setPurchases } from "./actions";
import purchaseService from "../../Services/PurchaseService";
import { IMakePurchaseRequest } from "../../Common/Requests/IMakePurchaseRequest";

export const fetchPurchases = () => {
  return async (dispatch: AppDispatch<PurchasesActions>) => {
    dispatch(setisFetching(true));
    if (tokenStorage.getUserDataFromToken() !== null) {
      const userId = await usersService
        .getByEmail(tokenStorage.getUserDataFromToken()?.email)
        .then((user) => {
          return user.id;
        });
      await purchaseService.getByUserId(userId).then((purchases) => {
        dispatch(setPurchases(purchases));
      });
    }

    dispatch(setisFetching(false));
  };
};

export const makePurchase = (request: IMakePurchaseRequest) => {
  return async (dispatch: AppDispatch<PurchasesActions>) => {
    if (tokenStorage.getUserDataFromToken() !== null) {
      const userId = await usersService
        .getByEmail(tokenStorage.getUserDataFromToken()?.email)
        .then((user) => {
          return user.id;
        });
      request.userId = userId;

      await purchaseService.makePurchase(request).then((result) => {
        fetchPurchases();
      });
    }
  };
};

export const deletePurchase = (id: number) => {
  return async (dispatch: AppDispatch<PurchasesActions>) => {
    await purchaseService.deleteById(id).then((result) => {
      fetchPurchases();
    });
  };
};
