import { axiosInstance } from '../utils/axios';
import { ISerial } from '../Common/Models/ISerial';

class SerialsService {
    public static async getAll(): Promise<Array<ISerial>> {
        const result = await axiosInstance.get(`api/Serial/all`).
            then((response) => response.data);
        return result;
    }

    public static async getById(id: number): Promise<ISerial> {
        const result = await axiosInstance.get(`api/Serial/${id}`).
            then((response) => response.data);
        return result;
    }
}

export default SerialsService;