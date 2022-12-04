import serialsService from "../../Services/SerialsService";
import { SerialsActions } from "./serialsReducer";
import { setSerials, setisFetching, setSerial, setRatings, setGenres } from "./actions";
import { AppDispatch } from "../store";
import ratingsService from "../../Services/RatingsService";
import { IRateSerialRequest } from "../../Common/Requests/RateSerialRequest";
import { ISerialsQueryFilter } from "../../Common/Models/ISerialsQueryFilter";

export const fetchSerials = () => {
  return async (dispatch: AppDispatch<SerialsActions>) => {
    dispatch(setisFetching(true));
    await serialsService.getAll().then((serials) => {
      dispatch(setSerials(serials));
      dispatch(setisFetching(false));
    });
  };
};

export const filterSerials = (filter: ISerialsQueryFilter) => {
  return async (dispatch: AppDispatch<SerialsActions>) => {
    dispatch(setisFetching(true));
    await serialsService.getSerialsByFilter(filter).then((serials) => {
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
      dispatch(setRatings(serial.ratings.serialRatings));

      dispatch(setisFetching(false));
    });
  };
};

export const rateSerial = (request: IRateSerialRequest) => {
  return async (dispatch: AppDispatch<SerialsActions>) => {
    await ratingsService.rateSerial(request).then(() => {
      fetchSerialById(request.serialId);
    });
  };
};

export const fetchGenres = () => {
  return async (dispatch: AppDispatch<SerialsActions>) => {
    dispatch(setisFetching(true));
    await serialsService.getGenres().then((genres) => {
      dispatch(setGenres(genres));
      dispatch(setisFetching(false));
    });
  };
};
