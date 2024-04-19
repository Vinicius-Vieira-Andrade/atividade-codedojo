import api from '../Service/Service'
import { useState } from "react";
import { AudioButton } from "../components/AudioButton/Index";
import { ButtonSave } from "../components/ButtonSave/ButtonSave";
import { Container } from "../components/Container/Style";
import { HeaderIn } from "../components/Header/Index";
import { Input1 } from "../components/Input1/Input1";
import { TextSave } from "../components/Text/TextSave";
import axios from 'axios';

export const Home = () => {
    const [texto, setTexto] = useState();
    const [audio, setAudio] = useState();


    async function convertToAudio() {
        await axios.post("/TextToSpeech", {
            texto: texto
        }).then((response) => {
            console.log(response.data);
        }).catch((error) => {
            console.log(error);
        })
    }
    return (
        <Container>
            <HeaderIn />
            <AudioButton />


            <Input1
                placeholder='Escreva aqui'
                placeholderTextColor='#FFF'

                value={texto}
                onChangeText={(text) => setTexto(text)}

            />

            <ButtonSave onPress={() => convertToAudio()}>
                <TextSave>Salvar</TextSave>
            </ButtonSave>
        </Container>
    )
}