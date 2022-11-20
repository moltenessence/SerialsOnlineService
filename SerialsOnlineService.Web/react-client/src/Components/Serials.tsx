import React, { useState } from 'react';
import SerialModal from './modals/SerialModal';
import InfoButton from "./other/InfoButton";
import { SerialsWrapper, SerialItem, Rating } from "./styles/Serials.style";

type SerialsProps = { }

const Serials: React.FC<SerialsProps> = () => {

    const [isSerialInfoOpened, openSerialInfo] = useState<boolean>(false);

    return (
        <React.Fragment>
            {isSerialInfoOpened ? <SerialModal openSerialInfo={openSerialInfo} /> : null}
            <SerialsWrapper>
                <SerialItem>
                    <h3>King of Thrones</h3>
                    <p>Amount of series: 15</p>
                    <p>Released: 2012</p>
                    <p>Genre: Fantasy</p>
                    <p>Subscription: Basic</p>
                    <Rating>Rating: 9.5</Rating>
                    <InfoButton callback={openSerialInfo} />
                </SerialItem>
                <SerialItem>
                    <h3>King of Thrones</h3>
                    <p>Amount of series: 15</p>
                    <p>Released: 2012</p>
                    <p>Genre: Fantasy</p>
                    <p>Subscription: Basic</p>
                    <Rating>Rating: 9.5</Rating>
                    <InfoButton callback={() => openSerialInfo(true)} />
                </SerialItem>
                <SerialItem>
                    <h3>King of Thrones</h3>
                    <p>Amount of series: 15</p>
                    <p>Released: 2012</p>
                    <p>Genre: Fantasy</p>
                    <p>Subscription: Basic</p>
                    <Rating>Rating: 9.5</Rating>
                    <InfoButton callback={() => openSerialInfo(true)} />
                </SerialItem>
            </SerialsWrapper>
        </React.Fragment>
    );
};

export default Serials;