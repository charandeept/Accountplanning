


export class OrgHierarchydata {
    public userid: any;
    public name: any;
    public parentId: any;
    public InfluencerOrKdm: any;
    public css: any;
    public gender:string;
    public roleDescription:any;
    public innovaDMID:any;
    public customerId:any;
    public innovaDM:any;
    public reportsTO_Name:any;
    public persona:string;
    public designation: any;
    public engagmentLevel: any;
    public linkedInUrl: any;
    public children: any;
   
    constructor(userid: any, name: string, parentId: any, InfluencerOrKdm: string, customerId:any,css: any, gender: string, innovaDMID: string,innovaDM:string, reoportsTO_Name:string, persona:string, linkedInUrl: string, designation: string, engagmentLevel: number,roleDescription:string,  children: any) {
        this.userid = userid;
        this.name = name;
        this.parentId = parentId;
        this.InfluencerOrKdm=InfluencerOrKdm;
        this.innovaDMID=innovaDMID;
        this.innovaDM=innovaDM;
        this.reportsTO_Name= reoportsTO_Name;
        this.customerId=customerId;
        this.engagmentLevel=engagmentLevel;
        this.linkedInUrl=linkedInUrl;
        this.css = css;
        
        this.persona=persona;
        this.designation = designation;

        this.gender = gender;
        this.roleDescription=roleDescription;
        this.children=children;
    }
}

export interface orgHierarcyEdit{
    name: any;
    gender:string;
    designation: any;
    InfluencerOrKdm: any;
    engagmentLevel: any;
    innovaDM:any;
    reportsTO_Name:any;
}