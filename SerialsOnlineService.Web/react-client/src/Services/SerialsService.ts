import { axiosInstance } from "../utils/axios";
import { ISerial } from "../Common/Models/ISerial";
import { ISerialWithRatings } from "../Common/Models/ISerialWithRatings";
import { ISerialsQueryFilter } from "../Common/Models/ISerialsQueryFilter";
import { IGroupedGenres } from "../Common/Models/IGropedGenres";

class SerialsService {
  public static async getAll(): Promise<Array<ISerial>> {
    const result = await axiosInstance
      .get(`api/Serial/all`)
      .then((response) => response.data);
    return result;
  }

  public static async getById(id: number): Promise<ISerialWithRatings> {
    const result = await axiosInstance
      .get(`api/Serial/ratings/${id}`)
      .then((response) => response.data);
    return result;
  }

  public static async getGenres () {
    const result = await axiosInstance
      .get<Array<IGroupedGenres>>(`api/Serial/genres/group`)
      .then((response) => response.data);
    return result;
  }

  public static async getSerialsByFilter(filter: ISerialsQueryFilter) {
    const amountOfSeries = filter?.amountOfSeries ? `&AmountOfSeries=${filter?.amountOfSeries}` : '';
    const releaseYear = filter?.releaseYear ? `&ReleaseYear=${filter?.releaseYear}` : '';
    const name = filter?.name ? `&Name=${filter?.name}` : '';
    const orderByReleaseDesc = filter?.orderByReleaseDesc ? `&OrderByReleaseDesc=${filter?.orderByReleaseDesc}` : ``;
    const orderByAmountOfSeriesDesc = filter?.orderByAmountOfSeriesDesc ? `OderByAmountOfSeriesDesc=${filter?.orderByAmountOfSeriesDesc}` : ``;

    const query = amountOfSeries
      .concat(releaseYear)
      .concat(name)
      .concat(orderByReleaseDesc)
      .concat(orderByAmountOfSeriesDesc);

      console.log(`api/Serial/filter?${orderByAmountOfSeriesDesc}${releaseYear}${name}${orderByReleaseDesc}${amountOfSeries}`);
    const result = await axiosInstance
      .get<Array<ISerial>>(`api/Serial/filter?${orderByAmountOfSeriesDesc}${releaseYear}${name}${orderByReleaseDesc}${amountOfSeries}`)
      .then((response) => response.data);

    return result;
  }
}

export default SerialsService;
