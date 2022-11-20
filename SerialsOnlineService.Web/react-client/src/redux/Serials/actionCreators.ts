import serialsService from "../../Services/SerialsService";
import { SerialsActions } from "./serialsReducer";
import { setSerials, setisFetching, setSerial } from "./actions";
import { AppDispatch } from "../store";

export const fetchSerials = () => {
    return async (dispatch: AppDispatch<SerialsActions>) => {
        dispatch(setisFetching(true));
        await serialsService.getAll().then((serials) => {
            dispatch(setSerials(serials));
            dispatch(setisFetching(false));
        });
    };
};

export const fetchSerialById = (id: number) => {
    return async (dispatch: AppDispatch<SerialsActions>) => {
        dispatch(setisFetching(true));
        await serialsService.getById(id).then((serial) => {
            dispatch(setSerial(serial));
            dispatch(setisFetching(false));
        });
    };
};
