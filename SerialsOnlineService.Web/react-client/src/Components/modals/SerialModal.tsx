import React, {useState, useEffect} from 'react';
import { Modal } from 'antd';
import { RatingText } from "../styles/Serials.style";
import { ISerialWithRatings } from '../../Common/Models/ISerialWithRatings';
import Ratings from '../Ratings';
import RateSerialForm from '../forms/RateSerialForm';
import { ISerialRatings } from '../../Common/Models/ISerialRatings';

type ModalProps = {
    openSerialInfo: React.Dispatch<React.SetStateAction<boolean>>;
    serialInfo: ISerialWithRatings | null;
    ratings: ISerialRatings | null,
    rateSerial: any
}

const SerialModal: React.FC<ModalProps> = ({ openSerialInfo, serialInfo, ratings, rateSerial }) => {
    const [serialId, setSerialId] = useState<number>(1);

        async function setSerialData() {
            setSerialId(serialInfo?.serial.id as number);
            console.log(serialId);               
        }

        useEffect(()=>{
            setSerialData();
        }, [ratings?.serialRatings.length]);


    return (
        <Modal bodyStyle={{overflow: 'auto', maxHeight: 'calc(100vh - 200px)' }} title={serialInfo?.serial.name} centered open={true} onOk={()=>openSerialInfo(false)} onCancel={()=>openSerialInfo(false)}>
            <p>Amount of series: {serialInfo?.serial.amountOfSeries}</p>
            <p>Released: {serialInfo?.serial.releaseYear}</p>
            <p>Genre: {serialInfo?.serial.genre}</p>
            <p>Description: {serialInfo?.serial.description}</p>
            <RatingText>Rating: {ratings?.average}</RatingText>
            <Ratings ratings={ratings?.serialRatings}/>
            <RateSerialForm serialId={serialId} rateSerial={rateSerial} openSerialInfo={openSerialInfo}/>
        </Modal>
    );
};

export default SerialModal;



