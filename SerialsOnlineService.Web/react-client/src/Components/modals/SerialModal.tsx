import React, {useState, useEffect} from 'react';
import { Modal } from 'antd';
import { RatingText } from "../styles/Serials.style";
import { ISerialWithRatings } from '../../Common/Models/ISerialWithRatings';
import Ratings from '../Ratings';
import RateSerialForm from '../forms/RateSerialForm';
import tokenStorage from '../../Services/TokenStorage';
import UsersService from '../../Services/UsersService';

type ModalProps = {
    openSerialInfo: React.Dispatch<React.SetStateAction<boolean>>;
    serialInfo: ISerialWithRatings | null;
}

const SerialModal: React.FC<ModalProps> = ({ openSerialInfo, serialInfo }) => {

    const serial = serialInfo?.serial;

    const [userId, setUserId] = useState<number>(1);

        async function setUser() {
            const userEmail = tokenStorage.getUserDataFromToken()?.email;
            const userId = await UsersService.getByEmail(userEmail).then((user)=> user.id) as number;
    
            setUserId(userId);
        }

        setUser();

    return (
        <Modal bodyStyle={{overflow: 'auto', maxHeight: 'calc(100vh - 200px)' }} title={serial?.name} centered open={true} onOk={()=>openSerialInfo(false)} onCancel={()=>openSerialInfo(false)}>
            <p>Amount of series: {serial?.amountOfSeries}</p>
            <p>Released: {serial?.releaseYear}</p>
            <p>Genre: {serial?.genre}</p>
            <p>Description: {serial?.description}</p>
            <RatingText>Rating: {serialInfo?.ratings.average}</RatingText>
            <Ratings ratings={serialInfo?.ratings.serialRatings}/>
            <RateSerialForm userId={userId} serialId={serialInfo?.serial.id as number}/>
        </Modal>
    );
};

export default SerialModal;



