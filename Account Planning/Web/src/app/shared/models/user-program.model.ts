import { JobProfile } from './job-profile.model';

export class UserProgram extends JobProfile {
    public programID: number;
    public programName: string;
    public programDescription: string;
    public programCategory: string;
    public prerequisites: Prerequisite[]
    public programStatusID?: number;
    public courses: UserCourse[];
    public attachments:File[];
}

export class UserCourse {
    public courseID: number;
    public courseName: string;
    public courseDescription: string;
    public coursePriority: string;
    public subProgramID?: number;
    public subProgramPriority: string;
    public wave: number;
    public prerequisites: Prerequisite[]
    public courseStatusID?: number;
    public topics: UserTopic[];
    public attachments: File[];
}

export class UserTopic {
    public referenceTopicID: number;
    public topicName: string;
    public source: string;
    public referenceLink: string;
    public topicStatusID?: number;
}

export class Prerequisite {
    id: number
    typeID: number
    name: string
}


export class File {
    name: string;
    file: string;
}