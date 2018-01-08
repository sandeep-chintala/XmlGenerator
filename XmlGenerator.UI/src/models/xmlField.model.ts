import {ChildXmlField} from './childXmlField.model';

export class XmlField {
    constructor() { }
    public key:string;
    public values: Array<ChildXmlField>;
    public childKey:Array<XmlField>;
}