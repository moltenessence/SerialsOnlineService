import React, {useState, useEffect} from 'react';
import { Modal } from 'antd';
import { RatingText } from "../styles/Serials.style";
import { ISerialWithRatings } from '../../Common/Models/ISerialWithRatings';
import Ratings from '../Ratings';
import RateSerialForm from '../forms/RateSerialForm';

type ModalProps = {
    openSerialInfo: React.Dispatch<React.SetStateAction<boolean>>;
    serialInfo: ISerialWithRatings | null;
}

const SerialModal: React.FC<ModalProps> = ({ openSerialInfo, serialInfo }) => {
    const [serialId, setSerialId] = useState<number>(1);

        async function setSerialData() {
            setSerialId(serialInfo?.serial.id as number);
            console.log(serialId);
        }

        useEffect(()=>{
            setSerialData();
        }, []);


    return (
        <Modal bodyStyle={{overflow: 'auto', maxHeight: 'calc(100vh - 200px)' }} title={serialInfo?.serial.name} centered open={true} onOk={()=>openSerialInfo(false)} onCancel={()=>openSerialInfo(false)}>
            <p>Amount of series: {serialInfo?.serial.amountOfSeries}</p>
            <p>Released: {serialInfo?.serial.releaseYear}</p>
            <p>Genre: {serialInfo?.serial.genre}</p>
            <p>Description: {serialInfo?.serial.description}</p>
            <RatingText>Rating: {serialInfo?.ratings.average}</RatingText>
            <Ratings ratings={serialInfo?.ratings.serialRatings}/>
            <RateSerialForm serialId={serialId}/>
        </Modal>
    );
};

export default SerialModal;



